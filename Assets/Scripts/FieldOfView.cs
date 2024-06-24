using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask; 
    private Mesh mesh;
    private Vector3 origin;
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }
    private void LateUpdate(){
        float fov = 360f;
        int rayCount = 180;
        float angle = 0f;
        float angleIncrease = fov / rayCount;
        float viewDistance = 10f;
        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];
 
        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++){
            Vector3 vertex;
            RaycastHit2D rh = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, layerMask);

            if (rh.collider != null){
                vertex = rh.point;
            }else {
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            }

            vertices[vertexIndex] = vertex;
            if(i > 0){
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;
                
                triangleIndex += 3;
            }
            vertexIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;
    }

    public void SetOrigin(Vector3 origin){
        this.origin = origin;
    }

    private Vector3 GetVectorFromAngle(float angle){
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
}
