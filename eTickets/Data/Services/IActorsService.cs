using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IActorsService
    {
        //Gets all Actors
        Task<IEnumerable<Actor>> GetAll();
        //Gets one Actor
        Actor GetById(int id);
        //Add Actor
        void Add(Actor actor);
        //Update Actor
        Actor Update(int id, Actor newActor);
        //Delete Actor
        void Delete(int id);
    }
}
