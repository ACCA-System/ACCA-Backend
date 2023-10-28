namespace ACCA_Backend.Utils
{
    public class Utils
    {
        public Guid GenerateToken() => Guid.NewGuid();
        public String GenerateTokenString()=>Guid.NewGuid().ToString();
    }
}
