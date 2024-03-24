namespace dotget_backend.Requests;

public class CreateProfessorRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public IFormFile? ProfilePicture { get; set; }

    public string Subjects { get; set; }
}