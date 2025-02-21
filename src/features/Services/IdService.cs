using System;
using Godot;

namespace DiceRolling.Services;

public static class IdService {
    public static string GenerateNewId() {
        return Guid.NewGuid().ToString();
    }

    public static void EnsureValidId(ref string id) {
        if (ValidationService.ValidateId(id)) {
            GD.PrintErr("Id is null, generating new Id");
            id = GenerateNewId();
        }
    }
}