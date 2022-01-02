import * as React from 'react';
import { connect } from 'react-redux';

const Home = () => (
  <div>
    <h1>Welcome!</h1>
    <p>
      My name is Simon and once in a while, i like to cook. <br/>
      Since i have gotten serious about cooking over the last year, i decided to make this website. <br/>
      The point is really only to store all the recipes i find which i like so i can remember them all. <br/>
      Its also so i can add the few little twists and turns i do myself so i dont have to remember them.
    </p>
  </div>
);

export default connect()(Home);
