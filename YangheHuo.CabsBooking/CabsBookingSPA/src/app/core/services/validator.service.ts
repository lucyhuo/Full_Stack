import { Injectable } from '@angular/core';
import { AbstractControl, AsyncValidatorFn, FormGroup, ValidationErrors } from '@angular/forms';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { PlaceService } from './place.service';


@Injectable({
  providedIn: 'root'
})
export class ValidatorService {

  constructor(private placeService: PlaceService) {

  }

  passwordValidator(control: AbstractControl) {
    // {6,100}           - Assert password is between 6 and 100 characters
    // (?=.*[0-9])       - Assert a string has at least one number
    // (?!.*\s)          - Spaces are not allowed
    // tslint:disable-next-line
    if (control.value.match(/^(?=.*\d)(?=.*[a-zA-Z!@#$%^&*])(?!.*\s).{6,100}$/)) {
      return null;
    } else {
      return { invalidPassword: true };
    }
  }

  passwordMatch(group: FormGroup) {
    // console.log('isnide password match');
    // console.log(group);
    const pass = group.get('password')?.value;
    const confirmPassword = group.get('confirmPassword')?.value;

    return pass === confirmPassword ? null : { passwordNotMatch: true };
  }


  ageValidaor(control: AbstractControl) {

    const convertAge = new Date(control.value);
    const timeDiff = Math.abs(Date.now() - convertAge.getTime());
    const currentAge = Math.floor((timeDiff / (1000 * 3600 * 24)) / 365);
    console.log("current age " + currentAge);
    if (currentAge < 15) {
      return { invalidAge: true };
    }
    return null;

  }

}
