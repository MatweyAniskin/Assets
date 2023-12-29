using Repository;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Loader
{

    [CreateAssetMenu(menuName = "Loader/BlockType")]
    public class BlockTypeLoader : Loader
    {
        [SerializeField] List<SimpleBlock> blocks = new List<SimpleBlock>();
        Queue<SimpleBlock> tempBlocks;

        public override bool Next()
        {
            if (tempBlocks.Count == 0)
                return false;
            BlockRepository.Set(tempBlocks.Dequeue());
            return true;
        }

        public override void StartWork(MonoBehaviour executor)
        {
            tempBlocks = new Queue<SimpleBlock>(blocks);
            BlockRepository.Clear();
        }
    }
}
