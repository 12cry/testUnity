using testUnity.common;
using testUnity.script.model;
using UnityEngine;

namespace testUnity.script.model.builder
{
    public class StaticBuilder : Builder {


        public override void build () {

            StaticVar.currentSelectedTile.setTileType (this.buildType);
            
        }
    }
}