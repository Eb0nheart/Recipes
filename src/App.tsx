import 'bootstrap/dist/css/bootstrap.css';
import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Recipes from './components/Recipes';

import './custom.css'

export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/recipes' component={Recipes} />
    </Layout>
);
