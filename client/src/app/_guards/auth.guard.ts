import { CanActivateFn } from '@angular/router';
import { AccountService } from '../_services/account.service';
import { inject } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

export const authGuard: CanActivateFn = (route, state) => {
  const accountServices = inject(AccountService);
  const toaster = inject(ToastrService);

  if (accountServices.currentUser()) {
    return true;
  } else {
    toaster.error('You shall not pass!');
    return false;
  }
  
};
