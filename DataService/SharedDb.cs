using System.Collections.Concurrent;
using ChatService.Models;

namespace ChatService.DataService;

public class SharedDb
{
    private readonly ConcurrentDictionary<string, UserConnection> _connection = new();

    public ConcurrentDictionary<string, UserConnection> Connection => _connection;
}
