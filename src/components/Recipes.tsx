import React, {useState} from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../store';
import * as RecipeStore from '../store/Recipe';
import CustomPopup from './Popup';
import RecipeComponent from './Recipe';


type Props =
    RecipeStore.RecipesState &
    typeof RecipeStore.actionCreators &
    RouteComponentProps<{}>;

const Recipes = (props: Props | undefined) => {
    const [showAddRecipe, setShowAddRecipe] = useState(false);

    if(props === undefined){
        return(
            <div>
                <h1>Error!</h1>
                <p>Shit dood, something went wrong...</p>
            </div>
        );
    }

    const promptForRecipe = () => {
        setShowAddRecipe(!showAddRecipe);
    }

    return (
        <div>
            <CustomPopup title='Add Recipe' show={showAddRecipe} close={() => setShowAddRecipe(false)}>
                <div className="input-group mb-3">
                    <span className="input-group-text">Title</span>
                    <input type="text" className="form-control" placeholder="Tatziki"/>
                </div>
                <div className="input-group">
                    <span className="input-group-text">Recipe</span>
                    <textarea className="form-control" aria-label="With textarea"></textarea>
                </div>
            </CustomPopup>
            <div className='btn btn-sm btn-success mb-2' onClick={() => promptForRecipe()}>Add Random Recipe</div>
            {props.recipes.sort(r => r.id).map(r => <RecipeComponent recipe={r} deleteRecipe={() => props.removeRecipe(r)}/>)}
        </div>
    );
};

export default connect(
    (state: ApplicationState) => state.recipe,
    RecipeStore.actionCreators)(Recipes);