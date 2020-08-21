package jdbcignite;

import java.io.Serializable;

public class person implements Serializable {
	private static final long serialVersionUID = 0L;

    private int id;

    private String name;

    public person() {
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id =id;

}
}
