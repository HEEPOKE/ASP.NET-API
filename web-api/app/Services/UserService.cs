using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using app.Models;

namespace app.services;

public class UserServices
{
    private readonly DbContext _context;

    public UserServices(DbContext context)
    {
        _context = context;
    }

    public bool UserExists(int id)
    {
        return _context.Set<User>().Any(u => u.Id == id);
    }
}
