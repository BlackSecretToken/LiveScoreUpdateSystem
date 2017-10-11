﻿using LiveScoreUpdateSystem.Data.Models.FootballFixtures;
using System;
using System.Collections.Generic;

namespace LiveScoreUpdateSystem.Services.Data.Contracts
{
    public interface IFixtureService
    {
        IEnumerable<Fixture> GetAll();

        void Add(string homeTeamName, string awayTeamName, DateTime? startTime);
    }
}
