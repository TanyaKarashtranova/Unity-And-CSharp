using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class FieldCreator : MonoBehaviour
{
    private SpriteShapeController shape;
    [SerializeField] private int numberOfFieldPoints = 20;
    [SerializeField] private float distanceBetweeenPoints = 10;
    [SerializeField] private int initialIndexPointPosition = 2;
    [SerializeField] private int maxTangentLenght = 3;
    [SerializeField] private int minTangetLenght = 2;
    [SerializeField] private int lowestPosition = 0;
    [SerializeField] private int highestPosition = 10;
    [SerializeField] private int scale = 200;
    [SerializeField] GameObject rock;
    [SerializeField] GameObject snowTree;    

    private void Start()
    {
        shape = GetComponent<SpriteShapeController>();
        float rockPositionY = rock.transform.position.y;
        float treePositionY = snowTree.transform.position.y;
        shape.spline.SetPosition(2, shape.spline.GetPosition(2) + Vector3.right * scale);
        shape.spline.SetPosition(3, shape.spline.GetPosition(3) + Vector3.right * scale);
        for (int i = 0; i < numberOfFieldPoints; i++)
        {
            int currentPointIndex = i + initialIndexPointPosition;
            float positionX = currentPointIndex * distanceBetweeenPoints;
            float positionY = Random.Range(lowestPosition, highestPosition);
            shape.spline.InsertPointAt(currentPointIndex, new Vector3(positionX, positionY));
            shape.spline.SetTangentMode(currentPointIndex, ShapeTangentMode.Continuous);
            shape.spline.SetLeftTangent(currentPointIndex, new Vector3(-maxTangentLenght, -minTangetLenght, 0));
            shape.spline.SetRightTangent(currentPointIndex, new Vector3(maxTangentLenght, minTangetLenght, 0));
            if (positionY < highestPosition / 2)
            {
                CloneRock(positionX, positionY + rockPositionY);
            }
            if (positionY > highestPosition / 2)
            {
                CloneTree(positionX, positionY + treePositionY);
            }
        }
    }

    private void CloneRock(float positionX, float positionY)
    {
        Instantiate(rock, new Vector3(positionX, positionY, 0f), Quaternion.identity);
    }

    private void CloneTree(float positionX, float positionY)
    {
        Instantiate(snowTree, new Vector3(positionX, positionY, 0f), Quaternion.identity);
    }
}

