using BlazorAppProg3.Data.Core;
using BlazorAppProg3.Data.Interfaces;
using BlazorAppProg3.Data.Models;

namespace BlazorAppProg3.Data.Services
{
    public class PersonasServices : RepositoryBase<PersonasModel>, IPersonaRepository
    {
        private readonly Context contexto;

        public PersonasServices(Context _contexto) : base(_contexto)
        {

            this.contexto = _contexto;

        }
        public override void Save(PersonasModel entity)
        {

            base.Save(entity);
            base.SaveChanges();
        }
        public override void Update(PersonasModel entity)
        {
            base.Update(entity);
            base.SaveChanges();
        }
        public override void Remove(PersonasModel entity)
        {
            entity.IsActive = false;
            base.Update(entity);
            base.SaveChanges();
        }
        public override List<PersonasModel> GetAll()
        {
            return this.contexto.Personas.Where(cd => cd.IsActive).ToList();
        }

        public override PersonasModel GetEntity(int predicate)
        {
            return this.contexto.Personas.FirstOrDefault(cd => cd.Id == predicate);
        }
    }
}
