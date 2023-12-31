﻿using H2KT.Core.Constants;
using H2KT.Core.Models.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace H2KT.Core.Utils
{
    public static class SecurityUtil
    {
        
        /// Hàm băm mật khẩu
        
        /// <param name="rawPassword"></param>
        
        public static string HashPassword(string rawPassword)
        {
            return BC.HashPassword(rawPassword);
        }

        
        /// Hàm xác minh mật khẩu
        
        /// <param name="rawPassword"></param>
        /// <param name="hash"></param>
        
        public static bool VerifyPassword(string rawPassword, string hash)
        {
            return BC.Verify(rawPassword, hash);
        }

        
        /// Gen jwt token
        
        /// <param name="user"></param>
        
        public static string GenerateToken(User user, IConfiguration configuration)
        {
            var appSettings = configuration.GetSection(AppSettingKey.AppSettingsSection);
            var secretKey = appSettings[AppSettingKey.JwtSecretKey];
            var issuer = appSettings[AppSettingKey.JwtIssuer];
            var audience = appSettings[AppSettingKey.JwtAudience];
            var lifeTime = SecurityUtil.GetAuthTokenLifeTime(configuration);

            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                        //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        //new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtClaimKey.UserId, user.UserId.ToString()),
                        new Claim(JwtClaimKey.UserName, user.UserName ?? ""),
                        new Claim(JwtClaimKey.Email, user.Email ?? ""),
                        //new Claim(JwtClaimKey.Status, ((int)user.Status).ToString()),
                        new Claim(JwtClaimKey.DictionaryId, user.DictionaryId?.ToString() ?? ""),
                     }),
                Expires = DateTime.UtcNow.AddMinutes(lifeTime),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            return jwtToken;
        }

        
        /// Lấy thời gian timeout của jwt (đơn vị phút)
        
        /// <param name="configuration"></param>
        
        public static int GetAuthTokenLifeTime(IConfiguration configuration)
        {
            var appSettings = configuration.GetSection(AppSettingKey.AppSettingsSection);
            int.TryParse(appSettings[AppSettingKey.JwtLifeTime], out int lifeTime);
            if (lifeTime == 0)
            {
                lifeTime = 60; // 1h
            }

            return lifeTime;
        }

        
        /// Mã hóa string
        
        /// <param name="key"></param>
        /// <param name="plainText"></param>
        
        public static string EncryptString(string plainText, string key = null, IConfiguration configuration = null)
        {
            byte[] iv = new byte[16];
            byte[] array;

            if(string.IsNullOrWhiteSpace(key) && configuration != null)
            {
                key = configuration.GetSection(AppSettingKey.AppSettingsSection)[AppSettingKey.SecretKey];
            }

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        
        /// Giải mã string
        
        /// <param name="key"></param>
        /// <param name="cipherText"></param>
        
        public static string DecryptString(string cipherText, string key = null, IConfiguration configuration = null)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            if (string.IsNullOrWhiteSpace(key) && configuration != null)
            {
                key = configuration.GetSection(AppSettingKey.AppSettingsSection)[AppSettingKey.SecretKey];
            }

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
