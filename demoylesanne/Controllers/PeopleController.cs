using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using demoylesanne.Models;

namespace demoylesanne.Controllers
{
    public class PeopleController : ApiController
    {
        // GET: api/PeopleController
        public IEnumerable<Person> Get()
        => Person.People;


        // GET: api/PeopleController/5
        public IEnumerable<Person> Get(string id)
        //{
        //    if (long.TryParse(id, out long socialSecurityId))
        //    {
        //        return Person.FindById(socialSecurityId);
        //    }
        //    else return Person.FindByFirstName(id);
        //}

        // annan ette stringi, kui saab longiks parsida, siis pöördub FindById meetodi poole, vastasel juhul FindByFirstName poole
        => (long.TryParse(id, out long socialSecurityId))
            ? Person.FindById(socialSecurityId)
            : Person.FindByFirstName(id);

        // POST: api/PeopleController
        // Ülesande püstituses oli kirjas, et HTTP POST kaudu peaks saama inimese ees- ja perekonnanime muuta, kuid tegin standardi järgi nii, et POST lisab (create).
        public void Post([FromBody]Person value)
        {
            value.Add();
        }

        // PUT: api/PeopleController/5
        // Ülesande püstituses oli kirjas, et HTTP PUT kaudu peaks saama inimesi lisada, kuid tegin standardi järgi nii, et PUT muudab (edit).
        public void Put(string id, [FromBody]Person value)
        // Sai lühendatud, sest Get(id) on üleval juba defineeritud. Annab ette IEnumerabli ja mitme sama eesnimega tegelase puhul muudab esimest.
            => Get(id).FirstOrDefault()?.Edit(value);
        

        // DELETE: api/PeopleController/5 
 
    }
}
