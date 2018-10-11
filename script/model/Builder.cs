using testUnity.constant;
using UnityEngine;

namespace testUnity.script.model {
    public abstract class Builder  : MonoBehaviour{

        public BuildType buildType;
        public string buildName;
        public int money;

        public abstract void build ();
    }
}