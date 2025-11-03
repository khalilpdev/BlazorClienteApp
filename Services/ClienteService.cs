using BlazorClienteApp.Models;
using System.Text.Json;

namespace BlazorClienteApp;

public class ClienteService
{
    private const string StorageKey = "clientes";
    private List<Cliente> _clientes = new();

    public ClienteService()
    {
        CarregarClientes();
    }

    public List<Cliente> ObterTodos()
    {
        return _clientes;
    }

    public Cliente? ObterPorId(Guid id)
    {
        return _clientes.FirstOrDefault(c => c.Id == id);
    }

    public void Adicionar(Cliente cliente)
    {
        cliente.Id = Guid.NewGuid();
        cliente.DataDoCadastro = DateTime.Now;
        _clientes.Add(cliente);
        SalvarClientes();
    }

    public void Atualizar(Cliente cliente)
    {
        var existente = _clientes.FirstOrDefault(c => c.Id == cliente.Id);
        if (existente != null)
        {
            existente.Nome = cliente.Nome;
            existente.Telefone = cliente.Telefone;
            existente.CpfCnpj = cliente.CpfCnpj;
            SalvarClientes();
        }
    }

    public void Remover(Guid id)
    {
        var cliente = _clientes.FirstOrDefault(c => c.Id == id);
        if (cliente != null)
        {
            _clientes.Remove(cliente);
            SalvarClientes();
        }
    }

    public List<Cliente> Filtrar(string? nome, string? telefone, string? cpfCnpj)
    {
        var query = _clientes.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(nome))
            query = query.Where(c => c.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(telefone))
            query = query.Where(c => c.Telefone.Contains(telefone));

        if (!string.IsNullOrWhiteSpace(cpfCnpj))
            query = query.Where(c => c.CpfCnpj.Contains(cpfCnpj));

        return query.ToList();
    }

    private void CarregarClientes()
    {
        var json = GetFromLocalStorage(StorageKey);
        if (!string.IsNullOrEmpty(json))
        {
            _clientes = JsonSerializer.Deserialize<List<Cliente>>(json) ?? new();
        }
    }

    private void SalvarClientes()
    {
        var json = JsonSerializer.Serialize(_clientes);
        SaveToLocalStorage(StorageKey, json);
    }

    private string? GetFromLocalStorage(string key)
    {
        // Simulação - em produção usar JSInterop
        return null;
    }

    private void SaveToLocalStorage(string key, string value)
    {
        // Simulação - em produção usar JSInterop
    }
}