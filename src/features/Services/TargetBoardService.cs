using System;

using DiceRolling.Grids;
using DiceRolling.Targets;

namespace DiceRolling.Services;

/// <summary>
/// Serviço para manipulação de tabuleiros de alvos.
/// </summary>
public class TargetBoardService {
    private static TargetBoardService? _instance;
    public static TargetBoardService Instance => _instance ??= new TargetBoardService();

    private TargetBoardService() { }

    public static void AddGrid(TargetBoardType targetBoard, int rows, int columns) {
        if (!ValidationService.ValidateGridDimensions(rows, columns)) {
            return;
        }
        targetBoard.Grids.Add(new GridType(rows, columns, 0, "G"));
        targetBoard.EmitSignal(nameof(TargetBoardType.SetupChanged));
    }


    public static void UpdateGrid(TargetBoardType targetBoard, int index) {
        if (index >= 0 && index < targetBoard.Grids.Count) {
            targetBoard.Grids[index].Cells.Resize(targetBoard.Grids[index].Rows * targetBoard.Grids[index].Columns);
            targetBoard.EmitSignal(nameof(TargetBoardType.SetupChanged));
        }
    }
}