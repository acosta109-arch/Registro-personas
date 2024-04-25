using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Registro_personas.DAL;
using Registro_personas.Models;
using System.Data;
using System.Linq.Expressions;

namespace Registro_personas.Services;

public class PersonasService
{
    public readonly Contexto _contexto;

    public PersonasService(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Existe(int id)
    {
        return await _contexto.personas.AllAsync(p => p.PersonaId == id);
    }

    public async Task<bool> Insertar(Personas persona)
    {
        _contexto.personas.Add(persona);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Personas persona)
    {
        _contexto.personas.Update(persona);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Crear(Personas persona)
    {
        if (!await Existe(persona.PersonaId))
        {
            return await Insertar(persona);
        }
        else
        {
            return await Modificar(persona);
        }
    }

    public async Task<List<Personas>> Listar(Expression<Func<Personas, bool>> criterio)
    {
        return await _contexto.personas.AsNoTracking().Where(criterio).ToListAsync();
    }
}
