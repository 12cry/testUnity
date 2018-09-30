using testUnity.constant;

namespace testUnity.model {
    public abstract class Builder {

        public BuildType type;
        public string buildName;
        public int money;

        public abstract void build ();
    }
}