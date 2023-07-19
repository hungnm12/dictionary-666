namespace H2KT.Core.Models
{
    
    /// Lớp base cho các lớp model
    
    public class BaseModel
    {
        
        /// Hàm clone shallow đối tượng
        
        
        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
