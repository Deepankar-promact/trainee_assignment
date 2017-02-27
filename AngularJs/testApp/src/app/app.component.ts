import { Component } from '@angular/core';
import {Observable} from 'rxjs/Rx';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
  
})
export class AppComponent {
  flash = '';
  values = '';
  delay = 1000;
  words: string[] = [];
  textColor = "";
  bgColor = "";

  subscription;

  i = 0;

  constructor(){
    this.resetFlasher();
  }

  resetFlasher(){
    this.subscription = Observable.interval(this.delay)
      .subscribe(() => {
        this.flashWords();
      })
  }

  onKey(event: any){
    var sentence: string = event.target.value;
    this.words = sentence.split(" ");
    this.i = 0;
  }

  setDelay(delay: number){
    this.delay = delay;
    this.subscription.unsubscribe();
    this.resetFlasher();
  }

  flashWords(){
    this.flash = this.words[this.i];
    this.i = this.i == this.words.length - 1  ? 0 : this.i+1;
  }

  getTextColor(){
    return this.textColor;
  }

  getBgColor(){
    return this.bgColor;
  }


}
