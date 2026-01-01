namespace RelowFlow_api.Domain.Entities.User;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public GenderEnum? Gender { get; set; } = null;
    public string? Nif { get; set; } = string.Empty;
    public string? Niss { get; set; } = string.Empty;
    public string? RegisterNumber  { get; set; } = string.Empty;
    public string? Nacionalidad { get; set; } = string.Empty;
    public string? Naturalidad { get; set; } = string.Empty;
    public string? Profession { get; set; } = string.Empty;
    public decimal? Salary { get; set; } = null;
    public string? ZipCode { get; set; } = string.Empty;
    public string? StreetAddress { get; set; } = string.Empty;
    public string? StreetAddressNumber { get; set; } = string.Empty;
    public string? StreetAddressComplement { get; set; } = string.Empty;
    public string? City { get; set; } = string.Empty;
    public string? State { get; set; } = string.Empty;
    public string? Country { get; set; } = string.Empty;
    public string? PassportNumber { get; set; } = string.Empty;
    public DateOnly? PassportCreated { get; set; } = null;
    public DateOnly? PassportExpires { get; set; } = null;
    public bool HasVisa { get; set; } = false;
    public DateOnly? VisaStartDate { get; set; } = null;
    public DateOnly? VisaEndDate { get; set; } = null;
    public string? AnotherInformation { get; set; } = string.Empty;
    
    public bool ResetPassword { get; set; } = false;
    public DateTime? LastLogin { get; set; } = null;
    public UserStatusEnum Status { get; set; } =  UserStatusEnum.ACTIVE;
    public DateTime Created { get; set; } = new DateTime();
    public DateTime Updated { get; set; } = new DateTime();
    public DateTime? Deleted { get; set; } = null;
}