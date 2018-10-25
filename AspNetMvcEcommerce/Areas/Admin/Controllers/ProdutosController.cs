using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AspNetMvcEcommerce.Areas.Admin.Controllers
{
    [RoutePrefix("produtos")]
    public class ProdutosController : BaseController
    {
        [Route("")]
        public ActionResult Index()
        {
            var produtos = _ctx.Produtos.Include(p => p.Categoria);
            return View(produtos.ToList());
        }

        [Route("detalhes/{*id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = _ctx.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        [Route("criar")]
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(_ctx.Categorias, "Id", "Descricao");
            return View();
        }

        // POST: Admin/Produtoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("criar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Preco,Descricao,CategoriaId")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _ctx.Produtos.Add(produto);
                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(_ctx.Categorias, "Id", "Descricao", produto.CategoriaId);
            return View(produto);
        }

        [Route("editar")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = _ctx.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(_ctx.Categorias, "Id", "Descricao", produto.CategoriaId);
            return View(produto);
        }

        // POST: Admin/Produtoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("editar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Preco,Descricao,CategoriaId")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _ctx.Entry(produto).State = EntityState.Modified;
                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(_ctx.Categorias, "Id", "Descricao", produto.CategoriaId);
            return View(produto);
        }

        [Route("remover")]
        // GET: Admin/Produtoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = _ctx.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Admin/Produtoes/Delete/5
        [Route("remover")]
        [HttpPost, ActionName("remover")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = _ctx.Produtos.Find(id);
            _ctx.Produtos.Remove(produto);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
