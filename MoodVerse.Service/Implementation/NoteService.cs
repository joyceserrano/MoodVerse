﻿using MoodVerse.Data.Entity;
using MoodVerse.Repository.Interface;
using MoodVerse.Service.Dto.Note;
using MoodVerse.Service.Interface;

namespace MoodVerse.Service.Implementation
{
    public class NoteService : INoteService
    {
        private INoteRepository NoteRepository { get; }
        public NoteService(INoteRepository noteRepository)
        {
            NoteRepository = noteRepository;
        }

        public async Task InsertAsync(NoteDto noteDto)
        {
            var note = new Note()
            {
                Id = Guid.NewGuid(),    
                PrimaryEmotionTypeId = noteDto.PrimaryEmotionTypeId,
                Text = noteDto.Text,
                Title = noteDto.Title,
                CreatorId = noteDto.CreatorId,
                CreatedOn = DateTime.UtcNow,
            };

            await NoteRepository.InsertAsync(note);
            await NoteRepository.SaveChanges();
        }

        public async Task<(IEnumerable<Note>, int total)> GetAllAsync(Guid userId, int? skip = null, int? take = null)
        {
            return await NoteRepository.GetAllAsync(userId, skip, take);
        }
    }
}
