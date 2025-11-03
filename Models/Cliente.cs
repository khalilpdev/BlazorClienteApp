using System.ComponentModel.DataAnnotations;

namespace BlazorClienteApp.Models;

public class Cliente
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Nome é obrigatório")]
    [StringLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Telefone é obrigatório")]
    [Phone(ErrorMessage = "Telefone inválido")]
    public string Telefone { get; set; } = string.Empty;

    [Required(ErrorMessage = "CPF/CNPJ é obrigatório")]
    public string CpfCnpj { get; set; } = string.Empty;

    public DateTime DataDoCadastro { get; set; } = DateTime.Now;
}