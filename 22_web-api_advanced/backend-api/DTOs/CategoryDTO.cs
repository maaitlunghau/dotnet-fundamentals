namespace backend_api.DTOs;

public record CategoryDto(int Id, string Name);
public record CategoryCreateDto(string Name);