using Erstes = DemoModul006Lib.ErstesNamespace;
using Zweites = DemoModul006Lib.ZweitesNamespace;

namespace DemoModul006
{
    class Namespaces_Sample2_Alias
    {
        private Erstes.Club club1;
        private Zweites.Club club2;

        public void Test()
        {
            //bekommst null reference exception, das Objekt muss instanziiert werden 
            club1.ToString();
        }
    }
}
