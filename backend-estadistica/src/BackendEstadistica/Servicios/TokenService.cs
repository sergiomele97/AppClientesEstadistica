namespace BackendEstadistica.Servicios;

public class TokenService : ITokenService
{
    
    private readonly IConfiguration _configuration;

    
    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    public string GenerateJwtToken(ApplicationUser user)
    {
     
        var tokenHandler = new JwtSecurityTokenHandler();


        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.UserName), 
                new Claim(ClaimTypes.Email, user.Email) 
            }),
           
            Expires = DateTime.UtcNow.AddHours(1), 
  
            Issuer = _configuration["Jwt:Issuer"], 
            Audience = _configuration["Jwt:Audience"], 
          
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            )
        };

        
        var token = tokenHandler.CreateToken(tokenDescriptor);

      
        return tokenHandler.WriteToken(token);
    }
}
