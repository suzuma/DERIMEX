# DERIMEX
Patron de diseño Singleton en los Formularios

        private static frmAutentificar instancia = null;        

        public static frmAutentificar getIntancia(frmPanel padre) {
            if (instancia == null) {
                instancia = new frmAutentificar(padre);
            }
            return instancia;
        }

ESTE CODIGO SE DEBE ELIMINAR DE LA CLASE (EN EL CONSTRUCTOR)
     
     protected override void Dispose(bool disposing)
         {
             if (disposing && (components != null))
             {
                 components.Dispose();
             }
             base.Dispose(disposing);
             instancia = null;
         }
