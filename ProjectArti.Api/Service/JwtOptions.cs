namespace ProjectArti.Api.Service;

public class JwtOptions
{
    public string Issuer { get; set; }
    public string Audiences { get; set; }
    public string SecretKey { get; set; }
}

