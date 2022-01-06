import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../store';
import * as RecipeStore from '../store/Recipe';
import RecipeComponent from './Recipe';


type Props =
    RecipeStore.RecipesState &
    typeof RecipeStore.actionCreators &
    RouteComponentProps<{}>;

const Recipes = (props: Props | undefined) => {
    if(props === undefined){
        return(
            <div>
                <h1>Error!</h1>
                <p>Shit dood, something went wrong...</p>
            </div>
        );
    }

    return (
        <div>
            <h1>THE STUFF</h1>
            <div className='btn btn-sm btn-success' onClick={() => props.addRecipe({id: 1, description: "This is SOOOO delicious!!!", title: "BIATCH", })}>Add Random Recipe</div>
            {props.recipes.map(r => <RecipeComponent recipe={r}/>)}
        </div>
    );
};

export default connect(
    (state: ApplicationState) => state.recipe,
    RecipeStore.actionCreators)(Recipes);