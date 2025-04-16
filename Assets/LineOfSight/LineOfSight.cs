using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    private Mesh mesh;
    Vector3 viewStartPos;
    float startAimDir;
    [SerializeField]
    float fieldOfView = 45;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }
    void LateUpdate()
    {
       
        int rays = 50;
        float angle = startAimDir;
        float angleIncrease;
        float distancePlayerCanSee = 25;
       
         

        angleIncrease = fieldOfView / rays;

        Vector3[] points = new Vector3[rays + 1+1];
        Vector2[] uv = new Vector2[points.Length];
        int[] triangles = new int[rays * 3];
       
        points[0] = viewStartPos;

        int tempIndex = 1;
        int triIndex = 0;
        for (int i = 0; i <= rays; i++)
        {
            Vector3 vertex;
           RaycastHit2D rayCastHit = Physics2D.Raycast(viewStartPos, AngleToVector(angle), distancePlayerCanSee);
          //  Debug.DrawRay(viewStartPos, AngleToVector(angle), Color.red, distancePlayerCanSee);
            if(rayCastHit.collider == null)
            {
                vertex = viewStartPos + AngleToVector(angle) * distancePlayerCanSee;
            }
            else
            {
                vertex = rayCastHit.point;
                Debug.Log(rayCastHit.transform.gameObject.name);
            }
            points[tempIndex] = vertex;

            if(i > 0)
            {
                triangles[triIndex + 0] = 0;
                triangles[triIndex + 1] = tempIndex - 1;
                triangles[triIndex + 2] = tempIndex;
                triIndex += 3;
            }
            tempIndex++;
            angle -= angleIncrease;
        }


        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;


        mesh.vertices = points;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }
    private Vector3 AngleToVector(float angle)
    {
        float radian = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(radian),Mathf.Sin(radian));
    }
    public void SetStartPos(Vector3 pos)
    {
        this.viewStartPos = pos;
    }
    public void SetAimDir(Vector3 aimDir)
    {
        startAimDir = VectorToAngle(aimDir) + fieldOfView/2;
    }
    // Update is called once per frame
   public float VectorToAngle(Vector3 vect)
    {
        vect = vect.normalized;
        float thisAng = Mathf.Atan2(vect.y, vect.x) * Mathf.Rad2Deg;
        if(thisAng < 0)
        {
            thisAng += 360;
        }
        return thisAng;
    } 
}
