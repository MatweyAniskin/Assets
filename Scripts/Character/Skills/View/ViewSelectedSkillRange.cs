using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Skills
{
    public class ViewSelectedSkillRange : StepListener
    {
        [SerializeField] SkillsController controller;
        [SerializeField] ViewObject viewObjectPrefab;
        [SerializeField] Material viewMaterial;
        [SerializeField] int yOffset = -2;
        [SerializeField][Range(0.00000001f, 1)] float blockOffsetMultiply = 0.2f;
        float spawnY;
        ViewObject curViewObject;
        public override void OnStart()
        {
            controller.OnSetSkill += SetSkill;
            controller.OnDisableSkill += Clear;
            spawnY = (GenerateProperty.WalkebleLayer + yOffset) * GenerateProperty.BlockScale + GenerateProperty.BlockScale * blockOffsetMultiply;
        }
        public override void OnDelete()
        {
            controller.OnSetSkill -= SetSkill;
            controller.OnDisableSkill -= Clear;
            Clear();
        }
        void SetSkill(IEnumerable<ViewModel> views)
        {
            Clear();
            var mesh = new Mesh();
            List<Vector3> vertex = new List<Vector3>();
            List<Vector2> uvs = new List<Vector2>();
            List<int> triangles = new List<int>();
            foreach (var view in views)
            {
                foreach (var block in view.GetViewBlocks())
                {
                    vertex.Add(CalculateVertex(block, 0, 0));
                    vertex.Add(CalculateVertex(block, 1, 0));
                    vertex.Add(CalculateVertex(block, 0, 1));
                    vertex.Add(CalculateVertex(block, 1, 1));

                    triangles.Add(vertex.Count - 2);
                    triangles.Add(vertex.Count - 3);
                    triangles.Add(vertex.Count - 4);

                    triangles.Add(vertex.Count - 1);
                    triangles.Add(vertex.Count - 3);
                    triangles.Add(vertex.Count - 2);

                    uvs.Add(new Vector2(0, 0));
                    uvs.Add(new Vector2(0, 1));
                    uvs.Add(new Vector2(1, 0));
                    uvs.Add(new Vector2(1, 1));
                }
            }
            mesh.vertices = vertex.ToArray();
            mesh.triangles = triangles.ToArray();
            mesh.uv = uvs.ToArray();
            mesh.RecalculateNormals();

            curViewObject = Instantiate(viewObjectPrefab, Vector3.zero, Quaternion.Euler(Vector3.zero)) as ViewObject;
            curViewObject.Set(mesh, viewMaterial);
        }
        Vector3 CalculateVertex(Vector2Int pos, int x, int z) => (new Vector3(pos.x + x, 0, pos.y + z) * GenerateProperty.BlockScale + Vector3.up * spawnY);
        public override void StepAction()
        {
           // Clear();
        }
        void Clear()
        {
            if ( curViewObject != null && !curViewObject.IsDestroyed())
                curViewObject.Destroy();
        }
    }
}