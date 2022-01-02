import * as React from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu';

interface Props {
    children?: React.ReactNode
}

const Layout = (props: Props) => {
    return (
        <React.Fragment>
            <NavMenu />
            <Container>
                {props.children}
            </Container>
        </React.Fragment>
    );
}

export default Layout;