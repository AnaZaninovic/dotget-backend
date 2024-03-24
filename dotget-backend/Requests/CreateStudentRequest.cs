namespace dotget_backend.Requests;

public class CreateStudentRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public IFormFile? ProfilePicture { get; set; }
}