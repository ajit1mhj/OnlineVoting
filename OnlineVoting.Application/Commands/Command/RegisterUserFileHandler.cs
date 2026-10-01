using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlineVoting.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Application.Commands.Command
{
    public class RegisterUserFileHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public RegisterUserFileHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async  Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                FullName = request.FullName,
                DateOfBirth = request.DateOfBirth,
                State = request.State,
                City = request.City,
                Address = request.Address
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Voter");
            }
             return result.Succeeded;

        }
    }
}
