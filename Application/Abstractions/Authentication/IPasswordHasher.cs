﻿namespace Application.Abstractions.Authentication;

public interface IPasswordHasher
{
    public abstract string Hash(string password);

    public abstract (bool Verified, bool NeedsUpgrade) Check(string hash, string password);
}
