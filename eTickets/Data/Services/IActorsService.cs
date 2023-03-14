using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IActorsService
    {
        //Gets all Actors
        Task<IEnumerable<Actor>> GetAllAsync();
        //Gets one Actor
        Task<Actor> GetByIdAsync(int id);
        //Add Actor
        Task AddAsync(Actor actor);
        //Update Actor
        Task<Actor> UpdateAsync(int id, Actor newActor);
        //Delete Actor
        void Delete(int id);
    }
}
