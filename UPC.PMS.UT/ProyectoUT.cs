using UPC.PMS.DA;

namespace UPC.PMS.UT
{
    [TestClass]
    public class ProyectoUT
    {
        [TestMethod]
        public void ListarTodo()
        {
            var proyectoDA = new ProyectoDA();
            var proyectos = proyectoDA.ListarTodo();
            Assert.AreEqual(2,proyectos.Count);
        }
    }
}