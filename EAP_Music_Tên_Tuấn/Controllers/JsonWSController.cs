using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EAP_Music_Tên_Tuấn.Models;
using Newtonsoft.Json.Linq;

namespace EAP_Music_Tên_Tuấn.Controllers
{
    public class JsonWSController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/JsonWS
        //public IQueryable<Album> GetAlbums()
        //{
        //    return db.Albums;
        //}
        public JToken GetAlbums()
        {
            return JToken.FromObject(db.Albums);
        }

        // GET: api/JsonWS/5
        [ResponseType(typeof(Album))]
        //public IHttpActionResult GetAlbum(int id)
        //{
        //    Album album = db.Albums.Find(id);
        //    if (album == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(album);
        //}

        public JToken GetAlbum(int id)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return JToken.FromObject("Not Found");
            }

            return JToken.FromObject(db.Albums.Where(s=> s.AlbumId==id));
        }

        // PUT: api/JsonWS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAlbum(int id, Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != album.AlbumId)
            {
                return BadRequest();
            }

            db.Entry(album).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/JsonWS
        [ResponseType(typeof(Album))]
        public IHttpActionResult PostAlbum(Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Albums.Add(album);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = album.AlbumId }, album);
        }

        // DELETE: api/JsonWS/5
        [ResponseType(typeof(Album))]
        public IHttpActionResult DeleteAlbum(int id)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return NotFound();
            }

            db.Albums.Remove(album);
            db.SaveChanges();

            return Ok(album);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlbumExists(int id)
        {
            return db.Albums.Count(e => e.AlbumId == id) > 0;
        }
    }
}