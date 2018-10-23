using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AspNetMvcEcommerce.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    public class CategoriasController : BaseController
    {
        [Route("categorias")]
        public ActionResult Index()
        {
            return View(_ctx.Categorias.ToList());
        }

        [Route("categorias/{*id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = _ctx.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        [Route("categorias/create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("categorias/create")]
        public ActionResult Create([Bind(Include = "Id,Descricao")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _ctx.Categorias.Add(categoria);
                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        [Route("categorias/edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = _ctx.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Admin/Categorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("categorias/edit")]
        public ActionResult Edit([Bind(Include = "Id,Descricao")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _ctx.Entry(categoria).State = EntityState.Modified;
                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // GET: Admin/Categorias/Delete/5
        [Route("categorias/delete/{*id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = _ctx.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Admin/Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("categorias/Delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            Categoria categoria = _ctx.Categorias.Find(id);
            _ctx.Categorias.Remove(categoria);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
