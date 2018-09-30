using testUnity.model;

namespace testUnity.common {
    public class ModelRepository {

        public Land Land { get; set; }

        private ModelRepository () { }
        private static readonly ModelRepository m_instance = new ModelRepository ();
        public static ModelRepository instance {
            get {
                return m_instance;
            }
        }

    }
}