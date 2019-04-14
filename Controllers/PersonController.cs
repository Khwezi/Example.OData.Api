using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Person;
using System.Drawing;
using Microsoft.AspNet.OData;

namespace Example.OData.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    
    public class PersonController : ControllerBase
    {
        List<IParent> Parents { get; set; }

        public PersonController() => Parents = new List<IParent>()
            {
                new Parent()
                {
                    Name = "Joe",
                    Surname = "Soap",
                    Age = 26,
                    Inherited = new Trait()
                    {
                        EyeColor = Color.Black,
                        Gender = Sexes.Male,
                        HairColor = Color.Black,
                        Height = 167
                    }
                },
                new Parent()
                {
                    Name = "Jane",
                    Surname = "Doe",
                    Age = 26,
                    Inherited = new Trait()
                    {
                        EyeColor = Color.Brown,
                        Gender = Sexes.Female,
                        HairColor = Color.Orange,
                        Height = 80
                    }
                },
                new Parent()
                {
                    Name = "Son",
                    Surname = "Goku",
                    Age = 22,
                    Inherited = new Trait()
                    {
                        EyeColor = Color.Red,
                        Gender = Sexes.Male,
                        HairColor = Color.Orange,
                        Height = 163
                    }
                },
            };

        // GET: api/Person
        [HttpGet]
        [EnableQuery]
        public IEnumerable<IParent> GetParents() => Parents;
    }
}
