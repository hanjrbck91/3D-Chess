using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IObjectTweener))]
[RequireComponent (typeof(MaterialSetter))]
public abstract class Piece : MonoBehaviour
{
    private MaterialSetter materialSetter;

    public Board Board { protected get; set; }
    public Vector2Int OccupiedSquare { get; set; }
    public TeamColor Team { get; set; }
    public bool hasMoved { get; private set; }

    public List<Vector2Int> availableMoves;

    private IObjectTweener tweener;

    public abstract List<Vector2Int> SelectAvailableSquares();

    private void Awake()
    {
        availableMoves = new List<Vector2Int>();
        tweener = GetComponent<IObjectTweener>();
        materialSetter = GetComponent<MaterialSetter>();
        hasMoved = false;
    }

    public void SetMaterial(Material material)
    {
        materialSetter.SetSingleMaterial(material);
    }

    public bool IsFromSameTeam(Piece piece)
    {
        return Team == piece.Team;
    }

    public bool CanMoveTo(Vector2Int coords)
    {
        return availableMoves.Contains(coords);
    }

    public virtual void MovePiece(Vector2Int coords)
    {
        Vector3 targetPosition = Board.CalculatePositionFromCoords(coords);
        OccupiedSquare = coords;
        hasMoved = true;
        tweener.MoveTo(transform, targetPosition);
    }

    protected void TryToAddMove(Vector2Int coords)
    {
        availableMoves.Add(coords);
    }

    public void SetData(Vector2Int coords, TeamColor team, Board board)
    {
        this.Team = team;
        OccupiedSquare = coords;
        this.Board = board;
        transform.position = board.CalculatePositionFromCoords(coords);
    }
}
