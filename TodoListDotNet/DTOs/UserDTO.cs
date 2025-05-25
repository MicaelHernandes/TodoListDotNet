using Newtonsoft.Json;

namespace TodoListDotNet.DTOs;

public class UserDTO
{
    public string Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Mail { get; set; } = String.Empty;
}