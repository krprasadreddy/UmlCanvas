using System;
using TSF.ADL;

namespace TSF.UmlCanvas {

  public class Argument : Construct {
    private String superType;
    
    public Argument() {
      base.setType( "Argument" );
    }

    public new void setType( String type ) {
      this.superType = type;
    }
    
    public void setType( Class type ) {
      this.setType( type.getName() );
    }

    public Argument( String name, String type ) : this() {
      this.setName(name);
      this.setType( type );
    }

    public Argument( String name, Class type ) : this() {
      this.setName(name);
      this.setType( type );
    }
    
    public override void prepare() {
      if( this.superType != null ) {
        this.addSuper( this.superType );
      }
    }
  }
  
  public class Operation : Construct {
    private String returnType;
    private String visibility;
    private Boolean isStatic;
    private Boolean isAbstract;
        
    public Operation() {
      base.setType( "Operation" );
      this.setName( "NewOperation" );
    }

    public void setReturnType(String type) {
      this.returnType = type;
    }
    
    public void setReturnType(Class type ) {
      this.setReturnType( type.getName() );
    }
    
    public void setVisibility(String visibility) {
      this.visibility = visibility;
    }
    
    public void makeStatic() {
      this.isStatic = true;
    }
    
    public void makeAbstract() {
      this.isAbstract = true;
    }
    
    public void add( Argument argument ) {
      this.addChild( argument );  
    }
    
    public override  void prepare() {
      if( this.returnType != null ) {
        this.addSuper( this.returnType );
      }

      if( this.isStatic ) {
        this.addModifier( new Modifier( "static" ) );
      }
      
      if( this.isAbstract ) {
        this.addModifier( new Modifier( "abstract" ) );
      }

      if( this.visibility != null ) {
        this.addModifier( new Modifier( this.visibility ) );
      }
    }
  }
}