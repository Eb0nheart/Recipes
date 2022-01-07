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
            <div className='btn btn-sm btn-success mb-2' onClick={() => props.addRecipe({id: props.recipes.length === 0 ? 1 : props.recipes[props.recipes.length-1].id + 1, description: "This is SOOOO delicious!!!", title: "BIATCH", })}>Add Random Recipe</div>
            {props.recipes.sort(r => r.id).map(r => <RecipeComponent recipe={r} deleteRecipe={() => props.removeRecipe(r)}/>)}
        </div>
    );
};

export default connect(
    (state: ApplicationState) => state.recipe,
    RecipeStore.actionCreators)(Recipes);