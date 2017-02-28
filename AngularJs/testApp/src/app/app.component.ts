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

  randomTextColor: boolean = false;
  randomBgColor: boolean = false;

  color: string[] = ["#33cc33","#ff9933","#ff33cc","#3366ff","#006699","#ff3300","#cc33ff","#00ffcc","#ccff33","#663300","black","white"];

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

    if(this.flash === ""){
      this.randomTextColor = false;
      this.randomBgColor = false;
    }

    if(this.randomTextColor == true){
      this.textColor = this.pickRandomColor();
    }

    if(this.randomBgColor == true){
      this.bgColor = this.pickRandomColor();
    }

  }

  getTextColor(){
    return this.textColor;
  }

  getBgColor(){
    return this.bgColor;
  }

  pickRandomColor(){
    var pos;
    do{
      pos = Math.floor(Math.random() * this.color.length) + 1;
    }while(this.color[pos-1] == this.textColor || this.color[pos-1] == this.bgColor)

    return this.color[pos-1];
  }


}
