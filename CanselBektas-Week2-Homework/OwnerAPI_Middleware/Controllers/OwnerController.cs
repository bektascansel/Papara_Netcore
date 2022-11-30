using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OwnerAPI_Middleware.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OwnerAPI_Middleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        public static List<Owner> Owners = new List<Owner>()
        {
             new Owner
            {
                Id=1,
                Name="johnny",
                Surname="Depp",
                Date=new DateTime(2017,05,04),
                Comment="johnny depp",
                Type="owner",
            },
              new Owner
            {
                Id=2,
                Name="adriana",
                Surname="lima",
                Date=new DateTime(2018,06,04),
                Comment="adriana lima",
                Type="owner",
            },

                new Owner
            {
                Id=3,
                Name="john",
                Surname="wick",
                Date=new DateTime(2019,05,04),
                Comment="john wick",
                Type="owner",
            },
        };
        /// <summary>
        /// HttpGet metotu ile Owners listesini geri döndüren metot oluşturuldu 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ALL")]
        public List<Owner> Get()
        {
            var owners = Owners.OrderBy(x => x.Id).ToList();
            return owners;

        }



        /// <summary>
        /// HttpDelete ile birlikte istenilen kayıt mevcut ise silinir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Owner))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        [Route("DELETE")]
        public IActionResult DeleteOwner(int id)
        {
            var owner = Owners.SingleOrDefault(x => x.Id == id);
            if (owner is null)
                // return NotFound("searched ID not found");
                throw new BadHttpRequestException("searched ID not found");

            Owners.Remove(owner);
            return Ok("Deleted");
        }




        /// <summary>
        /// HttpPut ile birlikte verilen id'ye uyan bir kayıt var ise verilen bilgilerle 
        /// birlikte güncelleme işlemi yapar. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateOwner"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Owner))]
        [HttpPut]
        [Route("UPDATE")]
        public IActionResult UpdateOwner(int id, [FromBody] Owner updateOwner)
        {

            var owner = Owners.SingleOrDefault(x => x.Id == id);
            if (owner is null)
                // return NotFound("searched ID not found");
                throw new BadHttpRequestException("searched ID not found");


            owner.Id = updateOwner.Id != default ? updateOwner.Id : owner.Id;
            owner.Name = updateOwner.Name != default ? updateOwner.Name : owner.Name;
            owner.Surname = updateOwner.Surname != default ? updateOwner.Surname : owner.Surname;
            owner.Comment = updateOwner.Comment != default ? updateOwner.Comment : owner.Comment;
            owner.Type = updateOwner.Type != default ? updateOwner.Type : owner.Type;

            return Ok(owner);
        }



        /// <summary>
        /// HttpPost işlemi ile yeni kayıt oluşturulur eğer mevcut ise hata kotu döner.
        /// </summary>
        /// <param name="newOwner"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Owner))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Owner))]
        [HttpPost]
        [Route("CREATE")]
        public IActionResult AddOwner([FromBody] Owner newOwner)
        {

            var owner = Owners.SingleOrDefault(x => x.Id == newOwner.Id);
            if (owner != null)
               // return BadRequest("WRONG!!! exist Id");
              throw new BadHttpRequestException("WRONG!!! exist Id");

            if (newOwner.Comment.Contains("hack"))
                //return BadRequest("must not contain the phrase \"hack\"");
                throw new BadHttpRequestException("must not contain the phrase \"hack\"");


            Owners.Add(newOwner);
            return Ok("Created");

        }

    }

}

