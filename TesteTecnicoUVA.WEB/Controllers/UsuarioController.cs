using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TesteTecnicoUVA.WEB.Models.ViewModel;

namespace TesteTecnicoUVA.WEB.Controllers
{
    public class UsuarioController : Controller
    {
        private string _urlApiBase = "https://localhost:7134/api/";

        //View de todos os usuarios
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<UsuarioViewModel> usuarios = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_urlApiBase);

                //HTTP GET
                var responseTask = client.GetAsync("Usuario/TodosUsuarios");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<UsuarioViewModel>>();
                    readTask.Wait();

                    usuarios = readTask.Result;
                }
                else
                {
                    usuarios = Enumerable.Empty<UsuarioViewModel>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(usuarios);
            }
        }

        //View para criar novo usuario
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //Criando novo usuario
        [HttpPost]
        public ActionResult Create(UsuarioViewModel usuario)
        {
            if (usuario == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_urlApiBase);

                //HTTP POST
                var postTask = client.PostAsJsonAsync("Usuario", usuario);
                postTask.Wait();
                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Erro no Servidor. Contacte o Administrador.");
            return View(usuario);
        }

        //View para editar/atualizar usuario
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            UsuarioViewModel usuario = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_urlApiBase);

                //HTTP GET
                var responseTask = client.GetAsync("Usuario/" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UsuarioViewModel>();
                    readTask.Wait();

                    usuario = readTask.Result;
                }
            }

            return View(usuario);
        }

        //Edita/atualizar um usuario
        [HttpPost]
        public ActionResult Edit(UsuarioViewModel usuario)
        {
            if (usuario == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_urlApiBase);

                //HTTP PUT
                var putTask = client.PutAsJsonAsync("Usuario", usuario);
                putTask.Wait();
                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(usuario);
        }

        //Deleta um usuário
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            UsuarioViewModel usuario = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_urlApiBase);

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Usuario/" + id.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(usuario);
        }

        //Detalhes de um único usuario - simples get
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            UsuarioViewModel usuario = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_urlApiBase);

                //HTTP GET
                var responseTask = client.GetAsync("Usuario/" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UsuarioViewModel>();
                    readTask.Wait();

                    usuario = readTask.Result;
                }
            }

            return View(usuario);
        }
    }
}