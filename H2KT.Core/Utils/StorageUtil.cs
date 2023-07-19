using Firebase.Auth;
using Firebase.Storage;
using H2KT.Core.Constants;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace H2KT.Core.Utils
{
    public class StorageUtil
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private string FirebaseToken { get; set; }
        private string Email { get; set; }
        private string Password { get; set; }
        private string APIKey { get; set; }

        private string Storage { get; set; }

        public StorageUtil(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
            Email = _configuration[AppSettingKey.FirebaseConfigs.Email];
            Password = _configuration[AppSettingKey.FirebaseConfigs.Password];
            APIKey = _configuration[AppSettingKey.FirebaseConfigs.APIKey];
            Storage = _configuration[AppSettingKey.FirebaseConfigs.Storage];
        }

        
        /// Lấy token
        
        
        public async Task<string> GetFirebaseToken()
        {
            if(!string.IsNullOrEmpty(FirebaseToken))
            {
                return this.FirebaseToken;
            }
            var auth = new FirebaseAuthProvider(new FirebaseConfig(APIKey));
            var a = await auth.SignInWithEmailAndPasswordAsync(Email, Password);
            FirebaseToken = a.FirebaseToken;
            return FirebaseToken;
           
        }

        
        /// Upload file
        
        /// <param name="folderPath"></param>
        /// <param name="fileName"></param>
        /// <param name="file"></param>
        
        public async Task<string> UploadAsync(string folderPath, string fileName, byte[] file)
        {
            var stream = new MemoryStream(file);
            var token = await GetFirebaseToken();
            var cancellation = new CancellationTokenSource();
            var task = new FirebaseStorage(
                Storage,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(token),
                    ThrowOnCancel = true
                })
                .Child(_environment.EnvironmentName)
                .Child(folderPath)
                .Child(fileName)
                .PutAsync(stream, cancellation.Token);

            // Track progress of the upload
            //task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

            var downloadUrl = await task;
            return downloadUrl;
        }

        
        /// Get file url
        
        /// <param name="folderPath"></param>
        /// <param name="fileName"></param>
        
        public async Task<string> GetDownloadUrlAsync(string folderPath, string fileName)
        {
            var token = await GetFirebaseToken();
            var task = new FirebaseStorage(
                Storage,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(token),
                    ThrowOnCancel = true
                })
                .Child(_environment.EnvironmentName)
                .Child(folderPath)
                .Child(fileName)
                .GetDownloadUrlAsync();

            // Track progress of the upload
            //task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

            var downloadUrl = await task;
            return downloadUrl;
        }

        
        /// Xóa file
        
        /// <param name="folderPath"></param>
        /// <param name="fileName"></param>
        
        public async Task<bool> DeleteAsync(string folderPath, string fileName)
        {
            var token = await GetFirebaseToken();
            var task = new FirebaseStorage(
                Storage,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(token),
                    ThrowOnCancel = true
                })
                .Child(_environment.EnvironmentName)
                .Child(folderPath)
                .Child(fileName)
                .DeleteAsync();

            // Track progress of the upload
            //task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");
            await task;
            return true;
        }

    }
}
