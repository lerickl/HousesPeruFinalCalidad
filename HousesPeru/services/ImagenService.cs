using HousesPeru.DB;
using HousesPeru.Models;
using HousesPeru.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 

namespace HousesPeru.services
{
    public interface IImageService
    {
        void AddImagen(List<HttpPostedFileBase> imagen, int idInmueble);
        IEnumerable<Imagen> GetImagenes();
        Imagen GetImagenesByInmuebleId(int InmuebleId);
        IEnumerable<Imagen> GetAllImagenesByInmuebleID(int InmuebleId);
        void DelImg(int id);
        List<JsonImagen> getAllImgs();
    }
    public class ImagenService:IImageService
    {
        public readonly HousesInPeruContext _db;
        public readonly ICloudinaryService cloudService;
        public ImagenService(HousesInPeruContext _db,ICloudinaryService cloudService) 
        {
            this._db = _db;
            this.cloudService = cloudService;
        }
        public void AddImagen(List<HttpPostedFileBase> imagen, int idInmueble) {
          

            foreach (var imgs in imagen) {
                var img = new Imagen();
                if (imgs!= null) {
                  
                    img.InmuebleId = idInmueble;
                    var imgupload = cloudService.uploadImg(imgs);
                    img.Img = imgupload;
                    _db.Imagens.Add(img);
                    _db.SaveChanges(); 
                }   
            }

 

        } 
        public IEnumerable<Imagen> GetImagenes()
        {
            return _db.Imagens.ToList();
        }
         
        public Imagen GetImagenesByInmuebleId(int InmuebleId ) {

            return _db.Imagens.Where(x => x.InmuebleId == InmuebleId).FirstOrDefault() ;
        
        }
        public IEnumerable<Imagen> GetAllImagenesByInmuebleID(int InmuebleId) {

            return _db.Imagens.Where(x => x.InmuebleId == InmuebleId).ToList();
        }

        public void DelImg(int id)
        {
            var img=_db.Imagens.Where(x => x.ImagenId == id).FirstOrDefault();
            _db.Imagens.Remove(img);
            _db.SaveChanges();
        }

        public List<JsonImagen> getAllImgs() {
            var idinm = _db.Inmuebles.Select(x => x.InmuebleId).ToList();
            var idimg = new List<JsonImagen>();
            foreach (var dat in idinm) 
            {
                var listimg = new JsonImagen();
               var img = _db.Imagens.Where(x => x.InmuebleId == dat).FirstOrDefault();
                listimg.ImagenId = img.ImagenId;
                listimg.Img = img.Img;
                listimg.InmuebleId = img.InmuebleId;

                idimg.Add(listimg);
            }

            return idimg.ToList() ;



        }
    }

  
}